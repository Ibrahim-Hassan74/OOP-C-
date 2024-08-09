namespace Model
{
    public class Library
    {
        List<Item> items;
        public Library()
        {
            items = new List<Item>();
        }
        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public void CheckOutItem(int isbn)
        {
            bool ok = false;
            foreach (var item in items)
            {
                if (item.Isbn == isbn && item.IsAvailable)
                {
                    ok = true;
                    item.IsAvailable = false;
                    break;
                }
            }
            if (ok)
                Console.WriteLine("Item is available");
            else
                Console.WriteLine("Item is not available");
        }
        public void ReturnItem(int isbn)
        {
            foreach (var item in items)
            {
                if (item.Isbn == isbn && !item.IsAvailable)
                {
                    item.IsAvailable = true;
                    break;
                }
            }
            Console.WriteLine("Done ..");
        }
        public void ListAvailableItems()
        {
            foreach (var item in items)
            {
                if (item.IsAvailable)
                {
                    item.DisplayInfo();
                    Console.WriteLine();
                }
            }
        }
    }
    public class Item
    {
        private String title;
        private int isbn;
        private bool isAvailable;
        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public int Isbn
        {
            get
            {
                return isbn;
            }
            set
            {
                isbn = value;
            }
        }
        public bool IsAvailable
        {
            get
            {
                return isAvailable;
            }
            set
            {
                isAvailable = value;
            }
        }
        public Item(String title, int isbn, bool isAvailable)
        {
            this.title = title;
            this.isbn = isbn;
            this.isAvailable = isAvailable;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Title is {title}\nisbn is {isbn}\n");
        }
    }

    public class Movie : Item
    {
        private String director;
        private int runtime;
        public String Director
        {
            get
            {
                return director;
            }
            set
            {
                director = value;
            }
        }
        public int Runtime
        {
            get
            {
                return runtime;
            }
            set
            {
                runtime = value;
            }
        }
        public Movie(String title, int isbn, bool isAvailable, String director, int runtime) : base(title, isbn, isAvailable)
        {
            this.director = director;
            this.runtime = runtime;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Director : {director}\nRuntime : {runtime}");
        }
    }

    public class Book : Item
    {
        private String author;
        public String Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }
        public Book(String title, int isbn, bool isAvailable, String author) : base(title, isbn, isAvailable)
        {
            this.author = author;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Author : {author}");
        }
    }
}
