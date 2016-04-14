function [r1, r2] = stegoDetect2(stegoImage, testImage)
%detects whether or not stegoImage contains a message using entropy
r1 = entropy(stegoImage(:,:,1)) + entropy(stegoImage(:,:,2)) + entropy(stegoImage(:,:,3));
r1 = r1/24;
r2 = entropy(testImage(:,:,1)) + entropy(testImage(:,:,2)) + entropy(testImage(:,:,3));
r2 = r2/24;
end
