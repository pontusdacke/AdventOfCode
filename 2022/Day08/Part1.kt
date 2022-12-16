import java.io.File
import java.io.InputStream

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream
        .bufferedReader()
        .use { it.readText() }
        .split("\n")
        .joinToString("")

    val n = 99
    val forest = BooleanArray(n * n) { false }
    var visibleTrees = n * 2 + (n - 2) * 2

    setOuterTreesVisible(forest, n)
    visibleTrees += fromAbove(n, forest, input)
    visibleTrees += fromBelow(n, forest, input)
    visibleTrees += fromLeft(n, forest, input)
    visibleTrees += fromRight(n, forest, input)
    println(visibleTrees)
    printArray(forest, n)
}

fun printArray(a: BooleanArray, n: Int) {
    for (y in 0 until n) {
        for (x in 0 until n) {
            val tmp = a[(y * n) + x]
            print(if (tmp) "a" else "b")
        }
        println()
    }
}

fun setOuterTreesVisible(forest: BooleanArray, n: Int) {
    for (w in 0 until n) {
        forest[w] = true // top
        forest[((n - 1) * n) + w] = true // bottom
    }

    for (h in 0 until n) {
        forest[h * n] = true
        forest[h * n + n - 1] = true
    }
}

fun fromAbove(n: Int, forest: BooleanArray, input: String): Int {
    var visible = 0
    for (w in 0 until n) {
        var highestTree = input[w].digitToInt()
        for (h in 1 until n) {
            val currentIndex = h * n + w
            val currentTree = input[currentIndex].digitToInt()

            if (currentTree > highestTree) {
                highestTree = currentTree
                if (!forest[currentIndex]) {
                    visible++
                    forest[currentIndex] = true
                }
            }
        }
    }
    return visible
}

fun fromLeft(n: Int, forest: BooleanArray, input: String): Int {
    var visible = 0
    for (h in 0 until n) {
        var highestTree = input[h * n].digitToInt()
        for (w in 1 until n) {
            val currentIndex = h * n + w
            val currentTree = input[currentIndex].digitToInt()

            if (currentTree > highestTree) {
                highestTree = currentTree
                if (!forest[currentIndex]) {
                    visible++
                    forest[currentIndex] = true
                }
            }
        }
    }
    return visible
}


fun fromBelow(n: Int, forest: BooleanArray, input: String): Int {
    var visible = 0
    for (w in 0 until n) {
        var highestTree = input[(n - 1) * n + w].digitToInt()
        for (h in n - 2 downTo 0) {
            val currentIndex = h * n + w
            val currentTree = input[currentIndex].digitToInt()

            if (currentTree > highestTree) {
                highestTree = currentTree
                if (!forest[currentIndex]) {
                    visible++
                    forest[currentIndex] = true
                }
            }
        }
    }
    return visible
}

fun fromRight(n: Int, forest: BooleanArray, input: String): Int {
    var visible = 0
    for (h in 0 until n) {
        var highestTree = input[(h * n) + n - 1].digitToInt()
        for (w in n - 2 downTo 0) {
            val currentIndex = h * n + w
            val currentTree = input[currentIndex].digitToInt()

            if (currentTree > highestTree) {
                highestTree = currentTree
                if (!forest[currentIndex]) {
                    visible++
                    forest[currentIndex] = true
                }
            }
        }
    }
    return visible
}

//kotlinc Part1.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part1Kt
