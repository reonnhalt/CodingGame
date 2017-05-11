import math._
import scala.util._

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
//AEDクラス
case class Defibrillator(id: Int, name: String, distance: Double)

object Solution extends App {
    val lon = readLine.replaceAll(",", ".").toDouble
    val lat = readLine.replaceAll(",", ".").toDouble
    val n = readInt
    var deflist: List[Defibrillator] = List()
    for(i <- 0 until n){
        val defib = readLine.split(';')
        val readId = defib(0).toInt
        val readName = defib(1)
        val readLongitude = defib(4).replaceAll(",", ".").toDouble
        val readLatitude = defib(5).replaceAll(",", ".").toDouble
        //先頭に要素を追加していく
        deflist = Defibrillator(readId,readName,calculateDistance(lon,lat,readLongitude,readLatitude)) :: deflist        
    }
    
    //リストのソート←sortWithで比較の関数渡し
    val sortedlist = deflist.sortWith( (a,b) => a.distance < b.distance )
    
    //距離最少要素の取り出し
    val mindef = deflist.minBy(_.distance)
    
    // Write an action using println
    // To debug: Console.err.println("Debug messages...")
    
    //println(sortedlist(0).name)
    println(mindef.name)

    //距離計算
    def calculateDistance(longitude1: Double, latitude1: Double, longitude2: Double, latitude2: Double): Double = {
        val x = (longitude2 - longitude1) * Math.cos((latitude1 + latitude2) / 2)
        val y = latitude2 - latitude1
        Math.sqrt( Math.pow(x,2) + Math.pow(y,2) ) * 6371
    }
}