import java.io.File
import java.io.InputStream

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream.bufferedReader().use { it.readText() }

    val splinput = input.split("\n\n")
    val allSums = mutableListOf<Int>()
    for (i in splinput) {
        val nums = i.split("\n")
        var current = 0
        for (n in nums) {
            current += n.toInt()
        }
        allSums.add(current)
    }
    allSums.sortDescending()
    print(allSums.take(3).sum())
}