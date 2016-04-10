imref = imread('standard_test_images/lake.bmp');
num1 = (entropy(imref));
noisy = imnoise(imref,'salt & pepper',0.02);
[pksnr] = psnr(noisy, imref);
imref2 = imread('standard_test_images - Modified/lake.bmp');
numba = entropy(imref2);
noisy = imnoise(imref2,'salt & pepper',0.02);
[pksnr2] = psnr(noisy, imref2);
disp(pksnr);
disp(pksnr2);
disp(num1/numba)