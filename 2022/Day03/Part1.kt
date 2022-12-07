import java.io.File
import java.io.InputStream

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream.bufferedReader().use { it.readText() }

    val rows = input.split("\n")
    var prio = 0
    for (row in rows) {
        var firstHalf = row.take(row.length / 2)
        var secondHalf = row.drop(row.length / 2).take(row.length / 2)

        var letter = firstHalf.toCharArray().intersect(secondHalf.toList()).single()
        if (letter.code > 96) {
            prio += letter.code - 96
        } else {
            prio += letter.code - 38
        }
    }
    println(prio)
}

/*
kotlinc Part1.kt -include-runtime -d test.jar; kotlin -classpath test.jar Part1Kt
 */
