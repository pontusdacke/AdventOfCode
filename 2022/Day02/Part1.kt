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

fun getScore(opponent: Char, me: Char): Int =
    when (opponent to me) {
        'A' to 'X',
        'B' to 'Y',
        'C' to 'Z' -> 3

        'A' to 'Y',
        'B' to 'Z',
        'C' to 'X' -> 6

        else -> 0
    }

//kotlinc Part1.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part1Kt
