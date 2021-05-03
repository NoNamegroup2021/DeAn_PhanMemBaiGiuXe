import cv2
import numpy
import os
import sys
import matplotlib

current_directory = os.getcwd()

"""Hàm Make_car_lisences_folder dùng để tạo tập folder biển số
trong tập ảnh positive 
"""
def make_car_lisences_folder(dulieu,save_path,path):
    datas = list(dulieu)
    for i in range(len(datas)):
        image_infos = list()
        image_infos = locals[i].split(' ')
        image_infos[-1] = image_infos[-1].strip()
        name_image = image_infos[0]
        count = image_infos[1]
        x = int(image_infos[2])
        y = int(image_infos[3])
        w = int(image_infos[4])
        h = int(image_infos[5])
        img_path = ('{}/{}'.format(path, name_image))
        img = cv2.imread(img_path, 1)
        crop_img = img[y:y + h, x:x + w] #mặt cắt của ảnh
        cv2.imwrite(save_path + name_image, crop_img)
    pass

path_posi = current_directory+'/adjective'

name_file = 'location.txt'

Folder1 = os.listdir(current_directory)

index = Folder1.index(name_file)

path_loca = ('{}/{}'.format(current_directory,name_file))

locals_file = open(path_loca,'rt',encoding='utf-8')
locals = list()
count = int

for data in locals_file:
    locals.append(data)
name_file_toSave = 'bienso'
path_to_save = current_directory + '/' + name_file_toSave +'/'

make_car_lisences_folder(locals,path_to_save,path_posi)



print('created folder for car-lisense')

