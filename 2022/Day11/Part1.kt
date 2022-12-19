import java.io.File
import java.io.InputStream

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream.bufferedReader().use { it.readText() }
        .split("\n")

    var monkeyMap = mutableMapOf<Int, Instruction>()
    var monkeyThrowMap = mutableMapOf<Int, Int>()

    for (chunk in input.chunked(7)) {
        val monkey = chunk[0].split(" ")[1].trimEnd(':').toInt()
        val items = chunk[1].split(":")[1].split(", ").map { it.trimStart().toInt() }
        val i = Instruction(
            items = items.toMutableList(),
            operation = chunk[2].split(":")[1].trim(),
            test = chunk[3].split(":")[1].trim().split(" ")[2].toInt(),
            ifTrue = chunk[4].split(":")[1].trim().split(" ")[3].toInt(),
            ifFalse = chunk[5].split(":")[1].trim().split(" ")[3].toInt(),
        )
        monkeyMap.put(monkey, i)
        monkeyThrowMap.put(monkey, 0)
    }

    for (round in 0 until 10000)
    for ((monkey, i) in monkeyMap) {
        var removes = mutableListOf<Int>()
        for (item in i.items) {
            removes.add(item)
            var newWorry = i.operate(item)
            newWorry = newWorry / 3
            val newMonkey = i.getMonkeyToThrowTo(newWorry)
            monkeyMap[newMonkey]!!.items.add(newWorry)
            monkeyThrowMap[monkey] = monkeyThrowMap[monkey]!! + 1
        }
        i.items.removeAll(removes)
    }
    val ordered = monkeyThrowMap.toList().sortedByDescending{(_, v) -> v}
    println(ordered[0].second * ordered[1].second)
}

class Instruction(
    val items: MutableList<Int>,
    val operation: String,
    val test: Int,
    val ifTrue: Int,
    val ifFalse: Int,
) {
    fun operate(item: Int): Int {
        val operator = operation.removePrefix("new = old ")[0]
        val value = operation.removePrefix("new = old " + operator + " ")
        return when (operator) {
            '*' -> if (value == "old") item * item else item * value.toInt()
            '+' -> if (value == "old") item + item else item + value.toInt()
            else -> throw Exception("invalid operator")
        }
    }

    fun getMonkeyToThrowTo(item: Int): Int {
        return if (item % test == 0) ifTrue else ifFalse
    }
}
/*
Mac
kotlinc Part1.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part1Kt
Windows
kotlinc Part1.kt -include-runtime -d test.jar; kotlin -classpath test.jar Part1Kt
*/