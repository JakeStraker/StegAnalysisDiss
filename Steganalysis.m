LSBEImg = imread('houseLSBE.bmp');
origImg = imread('house.bmp');
LSBOImg = imread('houseLSBO.bmp');
val = std2(LSBEImg);
val2 = std2(origImg);
val3 = std2(LSBOImg);
disp(val);
disp(val2);
disp(val3);