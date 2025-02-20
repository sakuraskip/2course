"use strict";
function createPhoneNumber(array) {
    if (array.length !== 10) {
        return;
    }
    return `(${array[0]}${array[1]}${array[2]}) ${array[3]}${array[4]}${array[5]}-${array[6]}${array[7]}${array[8]}${array[9]}`;
}
let a;
a = [1, 2, 3, 4, 7, 6, 3, 4, 1, 2];
console.log(createPhoneNumber(a));
class Challenge {
    static solution(number) {
        if (number <= 0) {
            return 0;
        }
        let sum = 0;
        for (let i = 0; i < number; i++) {
            if (i % 3 == 0 || i % 5 == 0) {
                sum += i;
            }
        }
        return sum;
    }
}
console.log(Challenge.solution(21));
function rotatearray(array, k) {
    let buff = new Array(array.length);
    for (let i = 0; i < array.length; i++) {
        let index = i + k;
        if (index >= array.length) {
            index = index % array.length;
            buff[index] = array[i];
        }
        else {
            buff[index] = array[i];
        }
    }
    return buff;
}
console.log(rotatearray([1, 2, 3, 4, 5, 6, 7], 10));
function findmedian(nums1, nums2) {
    let buff = [];
    let i = 0;
    let j = 0;
    while (i < nums1.length && j < nums2.length) {
        if (nums1[i] < nums2[j]) {
            buff.push(nums1[i]);
            i++;
        }
        else {
            buff.push(nums2[j]);
            j++;
        }
    }
    while (i < nums1.length) {
        buff.push(nums1[i]);
        i++;
    }
    while (j < nums2.length) {
        buff.push(nums2[j]);
        j++;
    }
    if (buff.length % 2 == 0) {
        let index1 = buff.length / 2;
        let index2 = index1 - 1;
        return (buff[index1] + buff[index2]) / 2;
    }
    else {
        let index = Math.floor(buff.length / 2);
        return buff[index];
    }
}
console.log(findmedian([3, 4, 7, 9, 10], [2, 4, 5, 7, 9])); // 2 3 4 4 5 7 7 9 9 10
