import java.io.File
import java.io.InputStream
import kotlin.collections.ArrayDeque

fun main() {
    val inputStream: InputStream = File("input.txt").inputStream()
    val input = inputStream.bufferedReader().use { it.readText() }

    val queue = ArrayDeque<Char>()

    for ((i, char) in input.withIndex()) {
        if (queue.size < 14) {
            queue.addLast(char)
            continue
        }

        if (queue.distinct().size == queue.size) {
            print(i)
            break
        }

        queue.removeFirst()
        queue.addLast(char)
    }
}

//kotlinc Part2.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part2Kt