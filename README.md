## Balanced Bracket
BalancedBracket digunakan untuk mengecek keseimbangan bracket dari sebuah inputan string. Fungsi utamanya ada di  
> Note: `IsValidParentheses()` dengan input string

Code : 

```sh
static bool IsValidParentheses(string input)
{
    Stack<char> stack = new Stack<char>();
    foreach (char c in input)
    {
        if (c == '(' || c == '[' || c == '{')
        {
            stack.Push(c);
        }
        else if (c == ')' && (stack.Count == 0 || stack.Pop() != '('))
        {
            return false;
        }
        else if (c == ']' && (stack.Count == 0 || stack.Pop() != '['))
        {
            return false;
        }
        else if (c == '}' && (stack.Count == 0 || stack.Pop() != '{'))
        {
            return false;
        }
    }
    return stack.Count == 0;
}
```

## Penjelasan

- Fungsi diatas melakukan perulangan sebayak character yang diinputkan
- Di dalam perulangan tersebut terdapat beberapa pengecekan :
  - Jika karakter tersebut adalah tanda kurung buka **( '(' , '[', atau '{' )**, karakter tersebut dimasukkan ke dalam stack.
  - Jika karakter tersebut adalah berisi kurung tutup **( ')' , ']' , atau '}' )**, fungsi memeriksa apakah stack kosong. Jika stack kosong, ini berarti tidak ada tanda kurung buka yang cocok, dan fungsi mengembalikan nilai false.
- Terakhir untuk menentukan apakah valid stack akan di hitung dengan fungsi **Count()**, jika kosong maka mengembalikan nilai **true**.