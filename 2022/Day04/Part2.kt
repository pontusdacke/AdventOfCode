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

        val map = mutableMapOf<Int, Int>()
        for (i1 in range1A..range1B) {
            map[i1] = map.getOrDefault(i1, 0) + 1
        }

        for (i2 in range2A..range2B) {
            map[i2] = map.getOrDefault(i2, 0) + 1
        }

        for ((_, value) in map) {
            if (value > 1) {
                total++
                break
            }
        }
    }

    println(total)
}

//kotlinc Part2.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part2Kt