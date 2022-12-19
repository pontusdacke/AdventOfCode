import java.io.File
import java.io.InputStream

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream.bufferedReader().use { it.readText() }
        .split("\n")

    var monkeyMap = mutableMapOf<Int, Instruction>()
    var monkeyThrowMap = mutableMapOf<Int, Long>()

    for (chunk in input.chunked(7)) {
        val monkey = chunk[0].split(" ")[1].trimEnd(':').toInt()
        val items = chunk[1].split(":")[1].split(", ").map { it.trimStart().toLong() }
        val i = Instruction(
            items = items.toMutableList(),
            operation = chunk[2].split(":")[1].trim(),
            test = chunk[3].split(":")[1].trim().split(" ")[2].toLong(),
            ifTrue = chunk[4].split(":")[1].trim().split(" ")[3].toInt(),
            ifFalse = chunk[5].split(":")[1].trim().split(" ")[3].toInt(),
        )
        monkeyMap.put(monkey, i)
        monkeyThrowMap.put(monkey, 0)
    }

    var commonDenominator = 1L
    for (t in monkeyMap.toList().map { it.second.test }) commonDenominator *= t

    for (round in 1..10000) {
        for ((monkey, i) in monkeyMap) {
            var removes = mutableListOf<Long>()
            for (item in i.items) {
                removes.add(item)
                var newWorry = i.operate(item)
                newWorry = newWorry % commonDenominator
                val newMonkey = i.getMonkeyToThrowTo(newWorry)
                monkeyMap[newMonkey]!!.items.add(newWorry)
                monkeyThrowMap[monkey] = monkeyThrowMap[monkey]!! + 1
            }
            i.items.removeAll(removes)
        }
    }
    val ordered = monkeyThrowMap.toList().sortedByDescending{(_, v) -> v}
    println(ordered[0].second * ordered[1].second)
}

class Instruction(
    val items: MutableList<Long>,
    val operation: String,
    val test: Long,
    val ifTrue: Int,
    val ifFalse: Int,
) {
    fun operate(item: Long): Long {
        val operator = operation.removePrefix("new = old ")[0]
        val value = operation.removePrefix("new = old " + operator + " ")
        return when (operator) {
            '*' -> if (value == "old") item * item else item * value.toLong()
            '+' -> if (value == "old") item + item else item + value.toLong()
            else -> throw Exception("invalid operator")
        }
    }

    fun getMonkeyToThrowTo(item: Long): Int {
        return if (item % test == 0L) ifTrue else ifFalse
    }
}

/*
Mac
kotlinc Part2.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part2Kt
Windows
kotlinc Part2.kt -include-runtime -d test.jar; kotlin -classpath test.jar Part2Kt
*/