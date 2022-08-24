for f in *-*.png
do
   i=$((i+1))
   convert $f +repage -crop 350x100+75+215 +repage bf_pretraga_1_$i.png
done
