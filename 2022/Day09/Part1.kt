import java.io.File
import java.io.InputStream

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream
        .bufferedReader()
        .use { it.readText() }
        .split("\n")

    val tailLocations = mutableSetOf(0 to 0)
    var tail = 0 to 0
    var head = 0 to 0
    for (line in input) {
        val temp = line.split(" ")
        val direction = temp[0]
        val value = temp[1].toInt()

        for (n in 0 until value) {
            when (direction) {
                "R" -> head = head.first + 1 to head.second
                "L" -> head = head.first - 1 to head.second
                "D" -> head = head.first to head.second - 1
                "U" -> head = head.first to head.second + 1
            }

            if (tooFar(tail, head)) tail = approach(tail, head)
            if (!tailLocations.contains(tail)) tailLocations.add(tail)
        }
    }

    println(tailLocations.size)
}

fun approach(a: Pair<Int, Int>, b: Pair<Int, Int>): Pair<Int, Int> {
    var dest = a
    if (b.first - a.first > 1 && b.second == a.second) dest = dest.first + 1 to dest.second
    else if (b.first - a.first > 1) dest = dest.first + 1 to b.second

    if (b.first - a.first < -1 && b.second == a.second) dest = dest.first - 1 to dest.second
    else if (b.first - a.first < -1) dest = dest.first - 1 to b.second

    if (b.second - a.second > 1 && b.first == a.first) dest = dest.first to dest.second + 1
    else if (b.second - a.second > 1) dest = b.first to dest.second + 1

    if (b.second - a.second < -1 && b.first == a.first) dest = dest.first to dest.second - 1
    else if (b.second - a.second < -1) dest = b.first to dest.second - 1

    return dest
}

fun tooFar(a: Pair<Int, Int>, b: Pair<Int, Int>): Boolean {
    return (a.first - 1 > b.first
            || a.second - 1 > b.second
            || a.first + 1 < b.first
            || a.second + 1 < b.second)
}

//kotlinc Part1.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part1Kt
