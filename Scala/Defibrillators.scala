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
    var answer = Defibrillator(-1, "", Double.MaxValue)
    for(i <- 0 until n){
        val defib = readLine.split(';')
        val readId = defib(0).toInt
        val readName = defib(1)
        val readLongitude = defib(4).replaceAll(",", ".").toDouble
        val readLatitude = defib(5).replaceAll(",", ".").toDouble
        val readDefibrillator = Defibrillator(readId,readName,calculateDistance(lon,lat,readLongitude,readLatitude))
        //距離の比較
        if(readDefibrillator.distance < answer.distance){
            answer = readDefibrillator
        }
    }
    
    // Write an action using println
    // To debug: Console.err.println("Debug messages...")
    
    println(answer.name)

    //距離計算
    def calculateDistance(longitude1: Double, latitude1: Double, longitude2: Double, latitude2: Double): Double = {
        val x = (longitude2 - longitude1) * Math.cos((latitude1 + latitude2) / 2)
        val y = latitude2 - latitude1
        Math.sqrt( Math.pow(x,2) + Math.pow(y,2) ) * 6371
    }
}