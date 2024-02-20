export interface LoginRequestDto{
    username: string | undefined;
    password: string | undefined;   
}
export interface ProductDetailDto {
    id: string;
    code?: string;
    importPrice: number;
    price: number;
    availableQuantity: number;
    status: number;
    upgrade?: string;
    description?: string;
    idProduct: string;
    idColor: string;
    idRam: string;
    idCpu: string;
    idHardDrive: string;
    idScreen: string;
    idCardVGA: string;
    maRam?: string;
    thongSoRam?: string;
    thongSoHardDrive?: string;
    maHardDrive?: string;
    maCpu?: string;
    tenCpu?: string;
    nameColor?: string;
    maColor?: string;
    nameProduct?: string;
    nameManufacturer?: string;
    nameProductType?: string;
    maManHinh?: string;
    kichCoManHinh?: string;
    tanSoManHinh?: string;
    chatLieuManHinh?: string;
    maCardVGA?: string;
    tenCardVGA?: string;
    thongSoCardVGA?: string;
    linkImage?: string;
    otherImages?: string[];
  }
  export interface ResponseDto {
    result: any;
    isSuccess: boolean;
    code: number;
    message: string;
    count: number;
  }