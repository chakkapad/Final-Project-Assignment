# Final-Project-Assignment
## POD <br/>
### ความเป็นมาของโปรแกรม
อยากขาย POD และ ดูด POD

<br/> <br/>
### วัตถุประสงค์ของโปรแกรม
1.อยากทำโปรแกรมขาย POD <br/>
2.อยากพัฒนาโปรแกรมขาย POD <br/>



<br/><br/>
### โครงสร้างของโปรแกรม
```mermaid 
classDiagram
    Program <-- From1
    From1 <-- Pod
    From1 <-- Eliqiud
    From1 <-- Accessories
    Program : +Main()
    class From1{
        +openToolStripMenuItem1_Click()
        +button1_Click()
        +saveToolStripMenuItem_Click()
        +button3_Click()
        printDocument1_PrintPage()
    }
    class Pod{
        +somk()
        +vopoo()
        +relx()
        +smoant()
    }
    class Eliqiud{
        +Allgrape()
        +Punthai()
        +Playmore()
        +Marbo()
    }
    class Accessories{
        +Coil()
        +Cotton()
        +Vapcelll()
        +Wire()
    }
 ```
    <br/> <br/>
### ผู้พัฒนาโปรแกรม
นายจักรพรรดิ์ อนุไพร 643450065-4
