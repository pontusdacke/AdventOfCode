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
        total += mine.code - 87;
        total += getScore(opponent, mine)
    }
    print(total)
}

fun getScore(opponent: Char, me: Char): Int {
    return when (opponent) {
        'A' -> when (me) {
            'X' -> 3
            'Y' -> 6
            else -> 0
        }
        'B' -> when (me) {
            'Y' -> 3
            'Z' -> 6
            else -> 0
        }
        'C' -> when (me) {
            'Z' -> 3
            'X' -> 6
            else -> 0
        }
        else -> 0
    }
}

//kotlinc Part1.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part1Kt
