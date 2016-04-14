originalImage = rgb2gray(imread('cameraman.bmp'));
lsboImage = rgb2gray(imread('cameramanLSBO.bmp'));
lsbeImage = rgb2gray(imread('cameramanLSBE.bmp'));
disp(entropy(originalImage));
disp(entropy(lsboImage));
disp(entropy(lsbeImage));
disp(mean(originalImage(:)));
disp(mean(lsboImage(:)));
disp(mean(lsbeImage(:)));