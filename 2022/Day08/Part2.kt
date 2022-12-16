import java.io.File
import java.io.InputStream
import kotlin.math.*

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream
        .bufferedReader()
        .use { it.readText() }
        .split("\n")
        .joinToString("")

    val n = 99
    var bestScenicScore = 0
    for (w in 0 until n)
        for (h in 0 until n) {
            val score = getScenicScore(n, w, h, input)
            if (score > bestScenicScore) {
                bestScenicScore = score
            }
        }

    println(bestScenicScore)
}

fun getScenicScore(n: Int, w: Int, h: Int, input: String): Int =
    (look(n, w, h, input, h + 1 until n) { it * n + w }
    * look(n, w, h, input, h - 1 downTo 0) { it * n + w }
    * look(n, w, h, input, w + 1 until n) { h * n + it }
    * look(n, w, h, input, w - 1 downTo 0) { h * n + it })

fun look(
    n: Int,
    startW: Int,
    startH: Int,
    input: String,
    range: IntProgression,
    getCurrentIndex: (elem: Int) -> Int
): Int {
    var visible = 0
    val centerTree = input[startH * n + startW].digitToInt()

    for (w in range) {
        val currentIndex = getCurrentIndex(w)
        val currentTree = input[currentIndex].digitToInt()
        visible++

        if (currentTree >= centerTree) {
            break
        }
    }

    return visible
}

//kotlinc Part2.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part2Kt