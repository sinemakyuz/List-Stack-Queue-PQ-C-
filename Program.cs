using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject1
{
    class Delivery  //TESLİMAT CLASS
    {
        public string food;  // hangi yemekten siparis verildiği
        public int countOfFood;  // kac adet sipariş verildiği

        public Delivery(string food, int countOfFood)  //constructor 
        {
            this.food = food;
            if (countOfFood <= 0) { Console.WriteLine("Yemek adeti 0 veya negatif bir sayı olamaz!"); }
            else { this.countOfFood = countOfFood; }
        }

        public override string ToString()
        {
            return "Sipariş edilen yemek: " + food + "   Adedi: " + countOfFood;
        }
    }

    class Districts  //MAHALLE CLASS 
    {
        public string districtName;   // mahalle adini tutar.
        public List<Delivery> genericlistDeliveries;  //Delivery tipinde veri tutacak olan generic list

        public Districts(string districtName, List<Delivery> genericListDeliveries)  //constructor
        {
            this.districtName = districtName;  //mahalle adi
            this.genericlistDeliveries = genericListDeliveries;
        }

        public override string ToString()
        {
            Console.WriteLine("Mahalle: " + districtName);
            foreach (Delivery delivery in genericlistDeliveries)
                if (genericlistDeliveries == null) { Console.WriteLine("Bu mahallenin hiç siparişi yok."); }  
                else { Console.WriteLine(delivery.ToString()); }
            return "";
        }
    }

    //SORU 2 İÇİN: MAHALLE NESNESİ TİPİNDE VERİ TUTAN STACK CLASSI
    class Stack
    {
        public List<Object> liste;  //object veri tipi içeren liste 
        public Stack()  //constructor
        {
            liste = new List<Object>();  //liste oluşturulur
        }
        public void push(Object mahalle)  // mahalle nesnesini ekler 
        {
            liste.Add(mahalle);
        }
        public Object pop()  // nesneyi sondan siler ve geri dondurur
        {
            if (isEmpty())
                return null;
            else
            {
                Object temp = liste[liste.Count - 1];   // listenin son elemanı geçici bir değişkene atanır
                liste.RemoveAt(liste.Count - 1);   // listenin son elemanı çıkarılır
                return temp;  // çıkarılan nesne geri döndürülür
            }
        }
        public bool isEmpty()  // stack boş ise true döner
        {
            return (liste.Count == 0);
        }
        public int countStack()  // stack eleman sayisini döndürür
        {
            return liste.Count;
        }
    }

    // SORU 2 İÇİN: MAHALLE NESNESİ TİPİNDE VERİ TUTACAK QUEUE SINIFI
    class Queues
    {
        public List<Object> liste;

        public Queues()  // constructor list oluşturulur
        {
            liste = new List<Object>(); 
        }

        public void add(Object mahalle)  // mahalle nesnesi eklenir
        {
            liste.Add(mahalle);
        }

        public Object delete()  // baştan siler ve silinen nesneyi döndürür
        {
            Object temp = liste[0];
            liste.RemoveAt(0);
            return temp;
        }

        public bool isEmpty()
        {
            return (liste.Count == 0);
        }

        public int countQueue()
        {
            return liste.Count;
        }
    } // end class queues


    //SORU 3 İÇİN: ELEMANLARI SONA EKLEYEN, SİLERKEN HER MAHALLENİN TESLİMAT SAYISINI BÜYÜKTEN KÜÇÜĞE SIRALI SİLEN VE DÖNDÜREN PRIORITY QUEUE CLASSI
    class PriorityQueue
    {
        public List<Districts> listem;

        public PriorityQueue()  // constructor  district nesneleri tutacak liste oluşturulur
        {
            listem = new List<Districts>();
        }
        public void add(Districts mahalle)  // mahalle nesnesi eklenir
        {
            listem.Add(mahalle);
        }

        public Districts delete()
        {
            //swap islemi ile liste sıralanır
            for (int s = 0; s < listem.Count; s++)    // karşılaştırmanın yapılacağı eleman
            {
                for (int y = s + 1; y < listem.Count; y++)  // karşılaştırıldığı eleman kendinden sonraki her eleman ile karşılaştırmayı yapar

                    if (listem[s].genericlistDeliveries.Count < listem[y].genericlistDeliveries.Count)  // eğer şart sağlanırsa yer değiştirilir 
                    {
                        Districts temp = listem[y];
                        listem[y] = listem[s];
                        listem[s] = temp;
                    }
            }
            Districts temp_ = listem[0];    // listenin ilk elemanı geçici değişkene atanır
            listem.RemoveAt(0);           // listenin sıralanmış halinde ilk eleman çıkarılır
            return temp_;               // ve döndürülür
        }
        public bool isEmpty()
        {
            return (listem.Count == 0);
        }
        public int countPq()
        {
            return listem.Count;
        }
    }

    // SORU 4 İÇİN YAZILMIŞ INTEGER TİPİ VERİ İÇİN QUEUE CLASSI
    class QueueForIntegers
    {
        private int size;  // dizinin boyutu
        private int[] queueDizi;  // queue dizisi
        private int first, last;   // ilk ve son elemanlar
        private int countElements;  // queue eleman sayısı
        public QueueForIntegers(int s) // constructure
        {
            size = s;
            queueDizi = new int[size];
            first = 0; last = -1; countElements = 0;
        }
        public void enque(int j) // listenin sonuna eleman ekler 
        {
            if (last == size - 1) 
                last = -1;
            queueDizi[++last] = j;  // önce last 1 arttırılır sonra int tipi veri eklenir
            countElements++;  // eleman sayısı bir arttırılır
        }
        public int deque() // listenin başındaki elemanı siler ve döndürür
        {
            int temp = queueDizi[first++];  // ilk elemanı geçici değişkene atayıp baş ı bir arttırır
            countElements--;  // eleman sayısı 1 azaltılır
            return temp;
        }
        public bool isEmpty() // kuyruk boşsa true döndürür
        {
            return (countElements == 0);
        }
    }

    // SORU 4 İÇİN: PRIORITY QUEUE NIN INTEGER TİPİ VERİ İCİN YAZILMIŞ CLASSI
    class PQinteger
    {
        public List<Int32> liste;

        public PQinteger()
        {
            liste = new List<Int32>();  //int tipinde List oluşturulur
        }
        public void add(int urunAdedi)  // sayi eklenir
        {
            liste.Add(urunAdedi);
        }

        public int delete()
        {//swap islemi ile liste sıralanır ustte yer alan PriorityQueue sınıfındaki delete() methodu ile aynı şekilde
            for (int s = 0; s < liste.Count; s++)  
            {
                for (int y = s + 1; y < liste.Count; y++)

                    if (liste[s] > liste[y])
                    {
                        int temp = liste[y];
                        liste[y] = liste[s];
                        liste[s] = temp;
                    }
            }
            int temp_ = liste[0];
            liste.RemoveAt(0);
            return temp_;
        }
        public bool isEmpty()
        {
            return (liste.Count == 0);
        }
        public int countPq()
        {
            return liste.Count;
        }
    }



    class Program
    {
        // SORU 1 İÇİN: siparişleri ve sayılarını random oluşturan, bunları generic liste atayan, daha sonra mahalle isimleriyle beraber arrayListe atayan method
        public static void orderFood(int[] TeslimatSayısı, string[] menu, string[] MahalleAdı, ArrayList motoKuryeArr, List<Districts> listHoldsDistricts)
        {
            Random random = new Random();    // random nesnesi oluşturulur

            for (int i = 0; i < TeslimatSayısı.Length; i++)  // her mahalle icin,
            {
                List<Delivery> genericListDeliveries = new List<Delivery>();


                if (TeslimatSayısı[i] == 0) { genericListDeliveries.Add(null); }  //(dongudeki mahalle icin hiç teslimat yoksa(0) listeye null eleman eklenir.)

                else
                {                                              //değilse
                    for (int j = 0; j < TeslimatSayısı[i]; j++)  // teslimat sayisi kadar,
                    {
                        int adet = random.Next(1, 8);               //hangi yemek ve kac adet oldugu random üretilerek
                        int menuIndex = random.Next(menu.Length);

                        Delivery delivery_ = new Delivery(menu[menuIndex], adet);  // Delivery nesnesi olusturulur ve son olarak

                        genericListDeliveries.Add(delivery_);   // generic listeye delivery(teslimat) nesnesi eklenir.
                    }

                    Districts district = new Districts(MahalleAdı[i], genericListDeliveries);  // Mahalle nesnesi olusturulur.
                    listHoldsDistricts.Add(district);
                    motoKuryeArr.Add(district);
                }
            }
        }

        public static void Display(ArrayList motoKuryeArr)  //generic listten oluşan arraylist i yazdırır
        {
            for (int d = 0; d < motoKuryeArr.Count; d++)
            {
                Console.WriteLine(motoKuryeArr[d].ToString());
            }
        }

        //MAIN 
        static void Main(string[] args)
        {
            string[] menu = { "Tost", "Pizza", "Hamburger", "Makarna", "Tavuk", "Köfte", "Mantı", "Fajita", "Wrap", "Waffle", "Döner", "Künefe", "Kumpir", "Çorba", "Pide" };

            string[] MahalleAdı = { "Özkanlar", "Evka 3", "Atatürk", "Erzene", "Kazımdirik", "Mevlana", "Doğanlar", "Ergene" };  //mahalleAdı dizisi oluşturulur.

            int[] TeslimatSayısı = { 5, 2, 7, 2, 7, 3, 0, 1 };  //teslimat sayısı dizisi oluşturulur.

            // soru 1 icin 
            ArrayList motoKuryeArr = new ArrayList();   
            List<Districts> listHoldsDistricts = new List<Districts>();   // soru 3 için kullanılacak mahalleleri tutan liste
            
            orderFood(TeslimatSayısı, menu, MahalleAdı, motoKuryeArr, listHoldsDistricts);  // orderFood() methodu çağırımı
            Display(motoKuryeArr);   // arraylist yazdırılır 1. soru için

            int arrCount = motoKuryeArr.Count;
            int sumOfDeliveries = 0;
            for (int i = 0; i < motoKuryeArr.Count; i++)
            {
                Districts temp = (Districts)motoKuryeArr[i];
                sumOfDeliveries += temp.genericlistDeliveries.Count();
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("Moto Kurye Arraylistindeki eleman sayısı (mahalle sayısı): " + (arrCount+1));
            Console.WriteLine("Moto Kurye Arraylistindeki teslimat sayısı: " + sumOfDeliveries);

            Console.WriteLine("---------------------------------------------------------------------");    // soru 2 stack oluşturma ve yazdırma
            Console.WriteLine("STACK");
            Console.WriteLine("--------------------------------");
            Stack stack1 = new Stack();
            for (int o = 0; o < motoKuryeArr.Count; o++)     // arraylist ten mahalle nesneleri stack e aktarılır
            {
                stack1.push(motoKuryeArr[o]);
            }
            while (stack1.countStack() > 0)     // her eleman çıkarılarak yazdırılır
            {
                Console.WriteLine(stack1.pop());
            }

            // soru 2 icin Queue gerçeklestirimi ve yazdırılması
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("QUEUE");
            Console.WriteLine("--------------------------------");
            Queues queue_ = new Queues();    // arraylistten mahalle nesneleri queue ya aktarılır
            for (int k = 0; k < motoKuryeArr.Count; k++)
            {
                queue_.add(motoKuryeArr[k]);
            }

            while (queue_.countQueue() > 0)   // tek tek mahalle nesneleri çıkarılıp yazdırılır
            {
                Console.WriteLine(queue_.delete());
            }

            // soru 3 priority queue
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("PRIORITY QUEUE SORTED BY THE AMOUNT OF DELIVERIES");
            Console.WriteLine("------------------------------------------------------");
            PriorityQueue pq = new PriorityQueue();
            Console.WriteLine("Priority Queue");

            for (int h = 0; h < listHoldsDistricts.Count; h++)    // list ten mahalle nesneleri aktarılır
            {
                pq.add(listHoldsDistricts[h]);
            }
            while (pq.countPq() > 0)    // tek tek çıkarılıp yazdırılır
            {
                Console.WriteLine(pq.delete());
            }

            //SORU 4:
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("BİR KASADAKİ MÜŞTERİLERİN ALDIKLARI ÜRÜN SAYILARINA GÖRE İŞLEM TAMAMLAMA SÜRELERİ");
            Console.WriteLine("-----------------------------------------------------------------------------------");

            int[] kacUrun = { 6, 7, 2, 1, 12, 5, 3, 7, 4, 2 };   // her müşterinin almış olduğu ürün sayısı

            QueueForIntegers kuyruk = new QueueForIntegers(kacUrun.Length);  //kuyruk oluşturulur müşterilerin aldığı ürün sayısı dizisinin uzunluğunda
            int toplamSure = 0;

            for (int t = 0; t < kacUrun.Length; t++)
            {
                int sure = kacUrun[t] * 3;
                kuyruk.enque(sure);     // kuyruğa her müşterinin süresi döngü ile eklenir
                toplamSure += sure;
            }

            while (!(kuyruk.isEmpty()))  //kuyruk boş değilken sırayla elemanları çıkaran ve döndüren method çağırılır
            {
                Console.WriteLine(kuyruk.deque());
            }

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Bu kasa için ortalama işlem tamamlama süresi: " + toplamSure / (kacUrun.Length) + " Saniye sürmektedir.");

            // SORU 4 İÇİN: PRIORITY CLASS İLE İŞLEM SURELERİ YAZDIRIMI

            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("BİR KASADAKİ MÜŞTERİLERİN ALDIKLARI ÜRÜN SAYILARINA GÖRE İŞLEM TAMAMLAMA SÜRELERİ KÜÇÜKTEN BÜYÜĞE:");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            PQinteger PQint = new PQinteger();

            for (int e = 0; e < kacUrun.Length; e++)
            {
                int sure_ = kacUrun[e] * 3;
                PQint.add(sure_);     // kuyruğa her müşterinin süresi döngü ile eklenir
            }

            while (!(PQint.isEmpty()))  //kuyruk boş değilken sırayla elemanları çıkaran ve döndüren method çağırılır
            {
                Console.WriteLine(PQint.delete());
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("Bu kasa için ortalama işlem tamamlama süresi: " + toplamSure / (kacUrun.Length) + " Saniye sürmektedir.");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");


            Console.ReadKey();

        } // end main

    } // end class program

} // end namespace 
