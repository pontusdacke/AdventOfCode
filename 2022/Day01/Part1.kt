import java.io.File
import java.io.InputStream

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream.bufferedReader().use { it.readText() }

    val splinput = input.split("\n\n")
    var biggest = 0
    for (i in splinput) {
        val nums = i.split("\n")
        var current = 0
        for (n in nums) {
            current += n.toInt()
        }
        if (current > biggest) {
            biggest = current
        }
    }
    print(biggest)
}