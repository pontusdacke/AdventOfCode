import java.io.File
import java.io.InputStream

fun main() {
    val totalAvailable = 70000000
    val requiredForUpdate = 30000000

    val inputStream: InputStream = File("input.txt").inputStream()
    val input: String = inputStream.bufferedReader().use { it.readText() }
    val rows: List<String> = input.split("\n")
    val fs = hashMapOf<String, Int>("/" to 0)

    var currentDir = "/"
    for (row in rows) {
        var line: List<String> = row.split(" ")

        if (line[0] == "$") {
            if (line[1] == "cd") currentDir = cd(currentDir, line[2])
        } else if (!line[0].startsWith("dir")) {
            val sum = line[0].toInt()
            addRecursively(currentDir, sum, fs)
        }
    }

    val folderToDelete = getSmallestFolderToDelete(fs, totalAvailable, requiredForUpdate, fs["/"]!!)
    println(folderToDelete)
}

fun getSmallestFolderToDelete(fs: HashMap<String, Int>, total: Int, required: Int, currentUsed: Int): Int {
    return fs.filterValues { total - currentUsed + it >= required  }
        .toList()
        .sortedBy { (_, value) -> value }
        .first()
        .second
}

fun addRecursively(path: String, sum: Int, fs: HashMap<String, Int>) {
    var currentPath = path
    while (currentPath != "/") {
        var exists = fs.get(currentPath)
        if (exists == null) {
            fs.put(currentPath, sum)
        } else {
            fs.set(currentPath, (fs[currentPath] ?: 0) + sum)
        }

        currentPath = back(currentPath)
    }

    fs.set("/", (fs["/"] ?: 0) + sum)
}

fun cd(currentPath: String, dir: String): String {
    return when (dir) {
        "/" -> "/"
        ".." -> back(currentPath)
        else -> {
            if (currentPath == "/") currentPath + dir
            else currentPath + "/" + dir
        }
    }
}

fun back(dir: String): String {
    val index = dir.lastIndexOf('/')
    if (index == 0) return "/"
    return dir.take(index)
}

//kotlinc Part2.kt -include-runtime -d test.jar && kotlin -classpath test.jar Part2Kt