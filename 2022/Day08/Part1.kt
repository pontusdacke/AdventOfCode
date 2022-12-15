import java.io.File
import java.io.InputStream

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream.bufferedReader().use { it.readText() }
}

//kotlinc Part1.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part1Kt
