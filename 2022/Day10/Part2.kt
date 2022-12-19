import java.io.File
import java.io.InputStream

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream.bufferedReader().use { it.readText() }
        .split("\n")
    var x = 1
    var cycle = 0
    var signalStrength = 0
    var latestMeasureCycle = 0
    var set = mutableSetOf<Int>()

    for (line in input) {
        if (shouldMeasureStrength(cycle, latestMeasureCycle)) {
            signalStrength += x * cycle
            latestMeasureCycle = cycle
        }

        if (line == "noop") {
            tryRender(cycle, x, set)
            cycle++
        } else {
            tryRender(cycle, x, set)
            cycle++
            if (shouldMeasureStrength(cycle, latestMeasureCycle)) {
                signalStrength += x * cycle
                latestMeasureCycle = cycle
            }
            tryRender(cycle, x, set)
            cycle++
            x += line.split(" ")[1].toInt()
        }
    }
    drawLetters(set)
}

fun shouldMeasureStrength(cycle: Int, latestMeasureCycle: Int) =
    (cycle == 20 || (cycle - 20) % 40 == 0) && latestMeasureCycle != cycle

fun tryRender(cycle: Int, x: Int, set: MutableSet<Int>) {
    if (cycle % 40 in x - 1..x + 1) set.add(cycle)
}

fun drawLetters(set: MutableSet<Int>) {
    for (y in 0 until 6) {
        for (x in 0 until 40) {
            if (set.contains(40 * y + x)) print("#")
            else print(".")
        }
        println()
    }
}

/*
Mac
kotlinc Part2.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part2Kt
Windows
kotlinc Part2.kt -include-runtime -d test.jar; kotlin -classpath test.jar Part2Kt
*/