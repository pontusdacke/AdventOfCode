import java.io.File
import java.io.InputStream
import kotlin.collections.ArrayDeque

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream.bufferedReader().use { it.readText() }
    val lines = input.split("\n")

    val stacks = listOf(
        ArrayDeque(listOf("Q", "S", "W", "C", "Z", "V", "F", "T")),
        ArrayDeque(listOf("Q", "R", "B")),
        ArrayDeque(listOf("B", "Z", "T", "Q", "P", "M", "S")),
        ArrayDeque(listOf("D", "V", "F", "R", "Q", "H")),
        ArrayDeque(listOf("J", "G", "L", "D", "B", "S", "T", "P")),
        ArrayDeque(listOf("W", "R", "T", "Z")),
        ArrayDeque(listOf("H", "Q", "M", "N", "S", "F", "R", "J")),
        ArrayDeque(listOf("R", "N", "F", "H", "W")),
        ArrayDeque(listOf("J", "Z", "T", "Q", "P", "R", "B"))
    )

    for (line in lines) {
        var tokens = line.split(" ")
        if (tokens[0] != "move") continue

        val move = tokens[1].toInt()
        val from = tokens[3].toInt()
        val to = tokens[5].toInt()

        for (i in 0..move - 1) {
            val temp = stacks[from-1].removeLast()
            stacks[to-1].addLast(temp)
        }
    }

    for (stack in stacks) {
        print(stack.last())
    }
}

//kotlinc Part1.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part1Kt
