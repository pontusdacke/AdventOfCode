import java.io.File
import java.io.InputStream

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream.bufferedReader().use { it.readText() }
    val lines = input.split("\n")
    var total = 0
    for (line in lines) {
        val ranges = line.split(",")
        val range1 = ranges[0].split("-")
        val range2 = ranges[1].split("-")
        val range1A = range1[0].toInt()
        val range1B = range1[1].toInt()
        val range2A = range2[0].toInt()
        val range2B = range2[1].toInt()
        if (range1A >= range2A && range1B <= range2B) {
            total++
        }
        else if (range2A >= range1A && range2B <= range1B) {
            total++
        }
    }

    println(total)
}

//kotlinc Part1.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part1Kt
