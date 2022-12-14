Факторизација броја
===================

Подсетимо се, реч `факторизација` значи растављање на просте факторе (просте чиниоце, тј. делиоце). 
Поступак факторизације је познат из основношколске математике, а овде ћемо га изразити формално и 
размотрити његову ефикасност. Хајде да најпре поставимо задатак прецизније:


.. questionnote::

    **Задатак - прости фактори броја**
    
    За дати цео број :math:`n` исписати све његове просте делиоце у неопадајућем редоследу, сваки у 
    посебном реду. При томе сваки делилац треба да буде исписан онолико пута, колико пута се он 
    појављује у факторизацији броја. На пример, за :math:`n=12` треба исписати бројеве :math:`2, 2, 3`.
    
Према основној теореми алгебре, сваки природан број :math:`n` на јединствен начин може да се представи 
као производ простих бројева, до на редослед чинилаца. Овде израз "до на редослед" значи да не правимо 
разлику између два производа ако се они разликују само у редоследу чинилаца. Ако просте бројеве 
:math:`2, 3, 5 \ldots` означимо редом са :math:`p_1, p_2, p_3 \ldots`, тада поменути јединствени растав 
обично записујемо као :math:`n = p_1^{\alpha_1} \cdot p_2^{\alpha_2} \ldots p_m^{\alpha_m}`. На пример, 
за :math:`n=12` растав је :math:`12 = 2^2 \cdot 3^1 = p_1^2 \cdot p_2^1`. 

Основна теорема алгебре гарантује да је задатак факторизације смислен, тј. добро постављен. Да би при 
томе излаз из алгоритма био потпуно одређен, у задатку смо увели и захтев да чиниоце треба исписати у 
неопадајућем редоследу. Дакле, задатак факторизације броја :math:`n` је да се одреди његов јединствени 
растав на просте чиниоце и да се за свако :math:`i` редом од :math:`1` до :math:`m` :math:`i`-ти прост 
број испише :math:`\alpha_i` пута.

Приликом одређивања простих чинилаца броја :math:`n` довољно је да редом проверавамо да ли су бројеви 
:math:`2, 3, 4, 5, 6, 7 \ldots` делиоци броја :math:`n`. Када наиђемо на делилац :math:`i` броја :math:`n`, 
исписујемо broj :math:`i` и делимо њиме број :math:`n`, а затим понављамо проверу дељивости :math:`n` са 
:math:`i`.

Покушајте да сами одговорите на питање: **када наиђемо на делилац** :math:`i` **броја** :math:`n`, **како 
знамо да је тај делилац прост?** До одговора није тешко доћи, ако знамо да смо број :math:`n` поделили свим 
претходно пронађеним делиоцима. 

Друго питање на које треба одговорити је када треба да престанемо са проверама дељивости броја :math:`n` 
бројевима :math:`i`. Овде можемо да искористимо размишљање објашњено у лекцији о тесту прималности. Наиме, 
закључили смо да ако број :math:`n` има нетривијалан прост делилац, онда он има и прост делилац мањи или 
једнак од :math:`\sqrt{n}`. Одавде следи да са проверама дељивости можемо да престанемо када потенцијални 
делилац :math:`i` премаши вредност :math:`\sqrt{n}`. У том тренутку, текућа вредност :math:`n`, ако је већа 
од :math:`1`, представља једини преостали прост делилац полазне вредности :math:`n`.

Користећи све наведене закључке, долазимо до следећег алгоритма. Програм исписује и време потребно за 
факторизацију учитаног броја, што можете да искористите за поређење са другим алгоритмима који решавају 
проблем факторизације. Међу улазе за тестирање уврстите неке велике просте бројеве, као и велике бројеве са 
мањим и већим бројем простих фактора. 

.. activecode:: faktorizacija
    :passivecode: true
    :coach:
    :includesrc: _src/1_algebarski/faktorizacija.cs

Лако се уочава да је у смислу ефикасности за овај алгоритам најнеповољнији улаз велики прост број, јер се 
тада петља извршава највећи број пута. У случају да је број :math:`n` прост, петља се извршава приближно 
:math:`\sqrt n` пута, па је сложеност алгоритма :math:`O(\sqrt n)`.

Додатним проверама дељивости пре петље може се постићи да у петљи проверавамо само непарне делиоце, или 
само делиоце који нису дељиви ни са 2 ни са 3. Таква оптимизација може да убрза програм 2 или 3 пута. 
Избацивање још неких потенцијалних делилаца проверама пре петље може још мало да смањи број пролазака кроз 
петљу, али број потребних операција у најнеповољнијем случају је и даље сразмеран са :math:`\sqrt n`. Зато 
је и код тако оптимизованих верзија алгоритма сложеност и даље :math:`O(\sqrt n)`.
