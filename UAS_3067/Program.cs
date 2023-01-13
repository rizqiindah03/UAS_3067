using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_3067
{
    class node
    {
        public int rollNumber;
        public string name;
        public string Jeniskelamin;
        public string kelas;
        public string kotaAsal;
        public node next;
    }
    class list
    {
        node START;

        public list()
        {
            START = null;
        }

        //Add a node in the list
        public void addNote()
        {
            int nim;
            string nm;
            string Jk;
            string K;
            string KA;
            Console.Write("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name student: ");
            nm = Console.ReadLine();
            Console.Write("\nEnter the Jeniskelamin: ");
            Jk = Console.ReadLine();
            Console.Write("\nEnter the Kelas: ");
            K = Console.ReadLine();
            Console.Write("\nEnter the KotaAsal: ");
            KA = Console.ReadLine();
            node newnode = new node();
            newnode.rollNumber = nim ;
            newnode.name = nm;
            newnode.Jeniskelamin = Jk;
            newnode.kelas = K;
            newnode.kotaAsal = KA;
            //if the node to be inserted the first node
            if (START == null || nim <= START.rollNumber) ;
            {
                if ((START != null) && (nim <= START.rollNumber)) ;
                {
                    Console.WriteLine("\nDuplicate roll number not allowed\n");
                    return;
                }
                newnode.next = START;
                START = newnode; 
                return;
            }

            //locate the osition of the new node in the list
            node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (nim >= current.rollNumber))
            {
                if (nim == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            //*once the above for loop is executed, prev and current are positition in such a imanner tat the 
            newnode.next = current;
            previous.next = newnode;
        }

        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nlist is empty.\n");
            else
            {
                Console.WriteLine("\nThe records in the list are: ");
                node currentnode;
                for (currentnode = START; currentnode != null;
                    currentnode = currentnode.next)

                    Console.Write(currentnode.rollNumber + "" + currentnode.name + currentnode.Jeniskelamin + currentnode.kelas + currentnode.kotaAsal + "\n");

                Console.WriteLine();
            }
        }
        public bool delNode(int nim)
        {
            node previous, current;
            previous = current = null;
            //check if the spesififed node is present in the list or not
            if (Search(nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }

        public bool Search(int rollNo, ref node previous, ref node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (rollNo != current.rollNumber))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        class Program
        {
            //check wheter the spesified node is present in the list or not

            static void Main(string[] args)
            {
                list obj = new list();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMenu");
                        Console.WriteLine("1. Add a record to the list ");
                        Console.WriteLine("2. Delete a record form the list ");
                        Console.WriteLine("3. View all the records in the list  ");
                        Console.WriteLine("4. Search for a records in the list ");
                        Console.WriteLine("5. EXIT ");
                        Console.Write("\nENter your choice (1-5) : ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.addNote();
                                }
                                break;
                            case '2':
                                {
                                    if (obj.listEmpty())
                                    {
                                        Console.WriteLine("\nlist is empty");
                                        break;
                                    }
                                    Console.Write("\nEnter the roll number of" + 
                                        "the student whose records is to be deleted :  ");
                                    int nim = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (obj.delNode(nim) == false)
                                        Console.WriteLine("\n Records not found.");
                                    else
                                        Console.WriteLine("Records with roll number "
                                            + nim + "Deleted");
                                }
                                break;
                            case '3':
                                {
                                    obj.traverse();
                                }
                                break;
                            case '4':
                                {
                                    if (obj.listEmpty() == true)
                                    {
                                        Console.WriteLine("\nlist is empty");
                                        break;
                                    }
                                    node previous, current;
                                    previous = current = null;
                                    Console.Write("\nEnter the roll number of the " +
                                        "student whose record is to be searched: ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref previous, ref current) == false)
                                        Console.WriteLine("\nRecord not found.");
                                    else
                                    {
                                        Console.WriteLine("\nRecord found");
                                        Console.WriteLine("\nroll number: " + current.rollNumber);
                                        Console.WriteLine("\nname: " + current.name);
                                        Console.WriteLine("\nJeniskelamin: " + current.Jeniskelamin);
                                        Console.WriteLine("\nKelas: " + current.kelas);
                                        Console.WriteLine("\nKotaAsal: " + current.kotaAsal);
                                    }
                                }
                                break;
                            case '5':
                                return;
                            default:
                                {
                                    Console.WriteLine("\nInvalid option");
                                    break;
                                }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nCheck for the value enterd");
                    }
                }
            }
        }
    }
}

//2.single linked list, karena  digunakan untuk pencarian, penambahan, dan juga penghapusan elemen dari list
//3. rear, front
//4. Ukuran dari linked list dapat diubah sesuai kebutuhan, sedangkan ukuran array tetap. Penambahan dan penghapusan elemen dari linked list lebih mudah dan efisien dibandingkan dengan array. linked list digunakan untuk implementasi stack dan queue, dan juga untuk penyimpanan dat yang banyak.
//5 a. parrent: 1 children: 5
//  b. preorder trversal : 20,10,5,10,15,15,12,16,18,20,30,32,20,25,20,28 
     