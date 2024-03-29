Проширени Еуклидов алгоритам
============================

У првом поглављу овог курса упознали смо се са Еуклидовим алгоритмом, којим се израчунава највећи 
заједнички делилац два дата природна броја. Сада ћемо видети како овај алгоритам може да се доради 
да би помоћу њега могла да се израчунају целобројна решења линеарних једначина са целобројним 
коефицијентима.

Проблем решавања поменуте врсте једначина је тесно повезан са мерењем. Као илустрација могу да 
послуже следећи задаци: 

1. Да ли и како може из великог бурета воде да се одмери 4 литра помоћу посуда од 3 и 5 литара?

2. Имамо два пешчана сата, од којих један мери 5, а други 7 минута. Да ли и како помоћу та два сата 
   може да се измери 18 минута?

3. Имамо комад креде, штап од 90cm, штап од 70cm и дугачку праву линију. Која је најмања дужина 
   коју можемо да измеримо и означимо на правој линији, користећи ова два штапа?

4. Имамо две врсте новчића у довољној количини. Маса првог новчића је 24 грама, а другог 9 грама. 
   Да ли на двостраној ваги само помоћу ових новчића (без тегова) може да се одмери у једном мерењу 
   39 грама? Ако може, како треба распоредити новчиће на тасове ваге да разлика маса на тасовима 
   буде 39 грама?

Ако су вас задаци привукли, овде можете да видите кратке одговоре на постављена питања и упоредите 
их са својим одговорима. 
  
.. reveal:: diofant_odgovori_na_pitanja
    :showtitle: Одговори на питања (брза провера)
    :hidetitle: Сакриј одговоре
    
    **Одговори:**
    
    1. Може. Посудом од 3 литра два пута сипамо у посуду од 5 литара. Када се посуда од 5 напуни, 
       испразнимо је и доспемо преосталих 1 литар из посуде од 3. На крају још једном доспемо из 
       посуде од 3 литра у посуду од 5 литара. 
    2. Може. На дати знак почнемо да меримо време на оба сата. После 5 минута преврнемо мањи, после 
       7 минута (од почетка) већи, после 10 опет мањи, а после 14 оба сата. Четири минута касније, 
       тј. после укупно 18 минута, мањи сат ће да се испразни, па смо тиме измерили 18 минута. 
    3. 10 cm (од почетне ознаке одмеримо 4 дужине краћег штапа надесно, а затим од места до ког смо 
       стигли 3 дужине дужег штапа налево).
    4. Може. На једну страну ваге ставимо 2 новчића од по 24 грама, а на другу 1 новчић од 9 грама 
       и предмет који меримо.

У наставку ћемо детаљније да размотримо решење задатка са новчићима (четврти задатак). 

Претпоставимо да решење постоји. То значи да на тасове ваге могу да се поставе новчићи једне или 
обе врсте, тако да разлика маса на тасовима буде тражених 39 грама. Изразимо ову претпоставку 
формалније: постоје ненегативни цели бројеви :math:`X_L, Y_L, X_D, Y_D`, такви да када на леву 
страну ваге ставимо :math:`X_L` новчића од 24 грама и  :math:`Y_L` новчића од 9 грама, а на десну 
:math:`X_D` новчића од 24 грама и :math:`Y_D` новчића од 9 грама, маса на левој страни ће бити 
већа за 39 грама од масе на десној страни. Сасвим формално: постоје 
:math:`X_L, Y_L, X_D, Y_D \in \mathbb{N}_0` такви да

.. math::

    \begin{aligned}
    &24 X_L + 9 Y_L = 24 X_D + 9 Y_D + 39\\
    \iff &24 (X_L - X_D) + 9 (Y_L - Y_D) = 39\\
    \iff &24 X + 9 Y = 39\\
    \end{aligned}

где су :math:`X = X_L - X_D, Y = Y_L - Y_D` цели бројеви. Са :math:`\mathbb{N}_0` је означен скуп 
бројева :math:`\{0, 1, 2, 3, ...\}`. 

Решавање задатка се сада своди на налажење целих бројева :math:`X, Y` који задовољавају последњу 
једначину. 

.. infonote::

    Једначине облика :math:`A X + B Y = C`, где су :math:`A, B, C` дати цели бројеви, а :math:`X, Y` 
    непознати цели бројеви које треба одредити, називају се **линеарне диофантске једначине**.
    
    Приметимо да се сви на почетку постављени задаци своде на линеарне диофантске једначине.

Онај ко је заинтересован само за решење овог конкретног задатка може из неколико покушаја 
и да погоди једно од решења. Ми ћемо искористити овај конкретан задатак да детаљније анализирамо 
проблем и дођемо до једног решења рачунањем, а затим уопштимо поступак и формулишемо алгоритам 
који решава и друге сличне проблеме.

Природно је да се на почетку запитамо које све масе можемо да измеримо помоћу датих новчића и у каквом 
су међусобном односу те масе. Уз мало испробавања или размишљања можемо да дођемо до закључка, који 
ћемо да означимо као тврђење 1.

**Тврђење 1:** Нека је :math:`m` најмања маса коју можемо да измеримо помоћу датих новчића. Тада су 
све остале масе које можемо да измеримо умношци од :math:`m`. 

Ово тврђење се лако доказује свођењем на контрадикцију.

.. reveal:: diofant_dokaz1
    :showtitle: Доказ
    :hidetitle: Сакриј доказ

    **Доказ**
    
    Претпоставимо супротно, то јест да постоји мерљива маса :math:`k \cdot m + r, 0 \leq r < m`.
    Тада је и :math:`r` мерљива маса, па :math:`m` није најмања мерљива маса, што је у контрадикцији
    са полазном претпоставком.

Било би нам корисно да одредимо најмању мерљиву масу :math:`m`, јер бисмо у случају да 39 није дељиво 
са :math:`m` одмах знали да нема решења. Размотримо зато какве особине има број :math:`m`.

Како је :math:`m` мерљива маса, важи да је :math:`m = X_0 \cdot A + Y_0 \cdot B` за неке целобројне 
:math:`X_0, Y_0`. Одавде следи да је :math:`m` дељив сваким бројем којим су дељиви и :math:`A` и 
:math:`B`, то јест:

.. math::

    d \in \mathbb{N}, d|24, d|9 \implies d|m

Специјално, ако за вредност :math:`d` изаберемо :math:`d_0 = nzd(24, 9)` закључујемо да :math:`nzd(24, 9) | m`,
а тиме и :math:`nzd(24, 9) \leq m`.

Са друге стране, спровођењем Еуклидовог алгоритма за налажење :math:`nzd(24, 9)`, можемо успут да добијемо 
:math:`nzd(24, 9)` као линеарну комбинацију бројева 24 и 9. Погледајмо прво како би текао поступак одређивања 
:math:`nzd(24, 9)`:

.. math::

    \begin{aligned}
    24 \bmod 9 = 6, (24 &= 2 \cdot 9 + 6)\\
    9 \bmod 6 = 3, (9 &= 1 \cdot 6 + 3)\\
    6 \bmod 3 = 0, (6 &= 2 \cdot 3 + 0)\\
    \end{aligned}

Приликом сваког дељења :math:`a \bmod b = r` важи :math:`a = k \cdot b + r`, па остатак :math:`r` 
можемо да изразимо као линеарну комбинацију бројева :math:`a, b`, тј. :math:`r = a - b \cdot k`. 
Пошто су :math:`a, b` остаци при дељењу из претходна два корака, они су линеарне комбинације претходних 
остатака. Закључујемо да је сваки остатак који се добија Еуклидовим алгоритмом линеарна комбинација 
полазних бројева 9 и 24. Потврдимо то на нашем примеру:

.. math::

    \begin{aligned}
    6 &= 1 \cdot 24 - 2 \cdot 9\\
    3 &= 1 \cdot 9 - 1 \cdot 6 = 1 \cdot 9 - 1 \cdot (1 \cdot 24 - 2 \cdot 9) = -1 \cdot 24 + 3 \cdot 9\\
    \end{aligned}

Последњи (ненулти) остатак који добијамо Еуклидовим алгоритмом је управо :math:`nzd(24, 9)`, 
што значи да је и он линеарна комбинација бројева 24 и 9. Самим тим, :math:`nzd(24, 9)` је и мерљив 
помоћу датих новчића, јер линеарна комбинација нам говори како можемо да распоредимо новчиће. Из 
тврђења 1 знамо да је сваки мерљив број умножак од :math:`m`, па је и :math:`nzd(24, 9) = k \cdot m` 
за неко :math:`k \in \mathbb{N}`, а одатле и :math:`nzd(24, 9) \geq m`. Како смо већ доказали 
:math:`nzd(24, 9) \leq m`, следи да је 

.. math::

    nzd(24, 9) = m

Преостали посао је сасвим једноставан. Претходним поступком смо добили да је 
:math:`nzd(24, 9) = 3 = -1 \cdot 24 + 3 \cdot 9`. Множењем обе стране једнакости са :math:`39/3=13`, 
добијамо :math:`39 = -13 \cdot 24 + 39 \cdot 9`. Закључујемо да масу од 39 грама можемо да измеримо 
стављањем 39 новчића од 9 грама на леву, а 13 новчића од 24 грама на десну страну ваге. 

Друга решења можемо да добијемо када приметимо да 24 новчића од по 9 грама имају исту масу као 9 
новчића од по 24 грама, или после скраћивања, да 8 новчића од по 9 грама има исту масу као 3 новчића 
од по 24 грама. Вага ће остати у равнотежи ако на левој страни додамо или уклонимо 8 новчића од по 9 
грама, а на десној 3 новчића од по 24 грама. Овај корак можемо да поновимо произвољан број пута.
Тако добијамо решења

- 39 новчића од 9 грама на левој, а 13 новчића од 24 грама на десној страни ваге
- 31 новчић од 9 грама на левој, а 10 новчића од 24 грама на десној страни ваге
- 23 новчића од 9 грама на левој, а 7 новчића од 24 грама на десној страни ваге
- 15 новчића од 9 грама на левој, а 4 новчића од 24 грама на десној страни ваге
- 7 новчића од 9 грама на левој, а 1 новчић од 24 грама на десној страни ваге

као и

- 47 новчића од 9 грама на левој, а 16 новчића од 24 грама на десној страни ваге
- 55 новчића од 9 грама на левој, а 19 новчића од 24 грама на десној страни ваге
- 63 новчића од 9 грама на левој, а 22 новчића од 24 грама на десној страни ваге

итд. Може се доказати да се на овај начин добијају сва могућа решења, али се тиме овде нећемо 
бавити.

~~~~

Погледајмо сада како би текао општи поступак. Нека су сада масе новчића :math:`A_0`, односно 
:math:`B_0` грама и нека је потребно да се измери :math:`C_0` грама. Током спровођења Еуклидовог 
алгоритма, сваки нови остатак ћемо да изразимо као линеарну комбинацију бројева :math:`A_0` и 
:math:`B_0`. Да бисмо то могли да урадимо, у сваком тренутку ћемо чувати коефицијенте из линеарних 
комбинација претходна два остатка, а та два остатка су управо текуће вредности :math:`A` и :math:`B`. 
Поступак се завршава када је :math:`B = 0`, а тада је :math:`A` најмањи заједнички делилац. 
Коефицијенти који :math:`A` изражавају као линеарну комбинацију од :math:`A_0` и :math:`B_0` су 
решење једначине :math:`X \cdot A_0 + Y \cdot B_0 = nzd(A_0, B_0)`. Програм на крају још треба да 
провери да ли је :math:`C_0` дељиво са :math:`nzd(A_0, B_0)` и ако јесте, да помножи обе стране 
последње једнакости њиховим количником.

.. activecode:: prosireni_euklid_iter
    :passivecode: true
    :coach:
    :includesrc: _src/1_algebarski/prosireni_euklid_iter.cs

Исти алгоритам има и елегантно рекурзивно решење.

.. activecode:: prosireni_euklid_rek
    :passivecode: true
    :coach:
    :includesrc: _src/1_algebarski/prosireni_euklid_rek.cs

Задатак
-------

Покажите како се остали задаци са почетка стране своде на линеарне диофантске једначине и решите их 
помоћу проширеног Еуклидовог алгоритма. 

|

На следећој страни се налази још неколико задатака који се решавају применом проширеног Еуклидовог 
алгоритма. 