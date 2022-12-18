import java.io.File
import java.io.InputStream

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream
        .bufferedReader()
        .use { it.readText() }
        .split("\n")

    val tailLocations = mutableSetOf(0 to 0)
    val knots = MutableList(10) { 0 to 0 }

    for (line in input) {
        val temp = line.split(" ")
        val direction = temp[0]
        val value = temp[1].toInt()

        for (n in 0 until value) {
            knots[0] = move(knots[0], direction)
            var knotToFollow = knots[0]

            for (i in 1 until knots.size) {
                if (tooFar(knots[i], knotToFollow)) knots[i] = approach(knots[i], knotToFollow)
                knotToFollow = knots[i]
            }

            if (!tailLocations.contains(knots.last())) tailLocations.add(knots.last())
        }
    }
    println(tailLocations.size)
}

fun move(knot: Pair<Int, Int>, direction: String): Pair<Int, Int> =
    when (direction) {
        "R" -> knot.first + 1 to knot.second
        "L" -> knot.first - 1 to knot.second
        "D" -> knot.first to knot.second - 1
        "U" -> knot.first to knot.second + 1
        else -> throw Exception("Invalid direction")
    }


fun approach(a: Pair<Int, Int>, b: Pair<Int, Int>): Pair<Int, Int> {
    var dest = a

    if (b.first - a.first > 1 && b.second - a.second > 1) {
        dest = dest.first + 1 to dest.second + 1
        return dest
    }

    if (b.first - a.first < -1 && b.second - a.second < -1) {
        dest = dest.first - 1 to dest.second - 1
        return dest
    }

    if (b.first - a.first > 1 && b.second - a.second < -1) {
        dest = dest.first + 1 to dest.second - 1
        return dest
    }

    if (b.first - a.first < -1 && b.second - a.second > 1) {
        dest = dest.first - 1 to dest.second + 1
        return dest
    }

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

//kotlinc Part2.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part2Kt
