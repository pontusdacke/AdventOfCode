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
    (lookDown(n, input, w, h) * lookUp(n, input, w, h) * lookRight(n, input, w, h) * lookLeft(n, input, w, h))


fun lookDown(n: Int, input: String, startW: Int, startH: Int): Int {
    var visible = 0
    val centerTree = input[startH * n + startW].digitToInt()

    for (h in startH + 1 until n) {
        val currentIndex = h * n + startW
        val currentTree = input[currentIndex].digitToInt()

        visible++

        if (currentTree >= centerTree) {
            break
        }
    }

    return visible
}

fun lookRight(n: Int, input: String, startW: Int, startH: Int): Int {
    var visible = 0
    val centerTree = input[startH * n + startW].digitToInt()

    for (w in startW + 1 until n) {
        val currentIndex = startH * n + w
        val currentTree = input[currentIndex].digitToInt()
        visible++

        if (currentTree >= centerTree) {
            break
        }
    }

    return visible
}

fun lookLeft(n: Int, input: String, startW: Int, startH: Int): Int {
    var visible = 0
    val centerTree = input[startH * n + startW].digitToInt()

    if (startW - 1 < 0) return 0

    for (w in startW - 1 downTo 0) {
        val currentIndex = startH * n + w
        val currentTree = input[currentIndex].digitToInt()
        visible++

        if (currentTree >= centerTree) {
            break
        }
    }

    return visible
}

fun lookUp(n: Int, input: String, startW: Int, startH: Int): Int {
    var visible = 0
    val centerTree = input[startH * n + startW].digitToInt()

    if (startH - 1 < 0) return 0

    for (h in startH - 1 downTo 0) {
        val currentIndex = h * n + startW
        val currentTree = input[currentIndex].digitToInt()

        visible++

        if (currentTree >= centerTree) {
            break
        }
    }

    return visible
}


//kotlinc Part2.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part2Kt