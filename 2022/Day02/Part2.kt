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

fun getScore(opponent: Char, me: Char): Int =
    when (me to opponent) {
        'X' to 'B' -> 1
        'X' to 'C' -> 2
        'X' to 'A' -> 3
        'Y' to 'A' -> 4
        'Y' to 'B' -> 5
        'Y' to 'C' -> 6
        'Z' to 'C' -> 7
        'Z' to 'A' -> 8
        'Z' to 'B' -> 9
        else -> 0
    }

//kotlinc Part2.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part2Kt