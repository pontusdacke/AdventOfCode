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

    for (line in input) {
        if (shouldMeasureStrength(cycle, latestMeasureCycle)) {
            signalStrength += x * cycle
            latestMeasureCycle = cycle
        }

        if (line == "noop") cycle++
        else {
            cycle++
            if (shouldMeasureStrength(cycle, latestMeasureCycle)) {
                signalStrength += x * cycle
                latestMeasureCycle = cycle
            }
            cycle++
            x += line.split(" ")[1].toInt()
        }
    }
    println(signalStrength)
}

fun shouldMeasureStrength(cycle: Int, latestMeasureCycle: Int) =
    (cycle == 20 || (cycle - 20) % 40 == 0) && latestMeasureCycle != cycle

/*
Mac
kotlinc Part1.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part1Kt
Windows
kotlinc Part1.kt -include-runtime -d test.jar; kotlin -classpath test.jar Part1Kt
*/