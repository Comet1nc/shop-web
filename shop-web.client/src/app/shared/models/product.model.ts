// export class Product {
//   constructor(
//     public id: string,
//     public price: string,
//     public name: string,
//     public description: string,
//     public count: number,
//     public cartCount: number
//   ) {
//     cartCount = 1;
//   }
// }

export interface ProductDto {
  id: number;
  price: string;
  name: string;
  description: string;
  count: number;
}

export interface Product {
  id: number;
  price: string;
  name: string;
  description: string;
  count: number;
  cartCount: number;
}
