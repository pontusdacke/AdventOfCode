import java.io.File
import java.io.InputStream

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream.bufferedReader().use { it.readText() }

    val rows = input.split("\n")
    var total = 0
    for (row in rows) {
        val letters = row.split(" ")
        val opponent = letters[0][0]
        val mine = letters[1][0]

        total += getScore(opponent, mine)
    }
    print(total)
}

fun getScore(opponent: Char, me: Char): Int {
    return when (me) {
        'X' -> when (opponent) {
            'A' -> 3
            'B' -> 1
            'C' -> 2
            else -> 0
        }
        'Y' -> when (opponent) {
            'A' -> 3 + 1
            'B' -> 3 + 2
            'C' -> 3 + 3
            else -> 0
        }
        'Z' -> when (opponent) {
            'A' -> 6 + 2
            'B' -> 6 + 3
            'C' -> 6 + 1
            else -> 0
        }
        else -> 0
    }
}

//kotlinc Part2.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part2Kt