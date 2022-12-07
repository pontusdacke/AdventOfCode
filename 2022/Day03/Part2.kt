import java.io.File
import java.io.InputStream

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream.bufferedReader().use { it.readText() }

    val rows = input.split("\n")
    var prio = 0
    for (chunk in rows.chunked(3)) {
        var letter =
            chunk[0].toCharArray().intersect(chunk[1].toList()).toCharArray()
                .intersect(chunk[2].toList()).toCharArray().first()

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
