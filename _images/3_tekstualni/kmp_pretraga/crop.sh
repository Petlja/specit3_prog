for f in *-*.png
do
   i=$((i+1))
   convert $f +repage -crop 1220x275+75+135 +repage kmp_$i.png
done
