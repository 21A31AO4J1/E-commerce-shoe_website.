export default interface CatalogProduct {
  id: string;
  name: string;
  title: string;
  description: string;
  price: number;
  stockQuantity: number;
  category: string;
  brand: string;
  size: string;
  color: string;
  imageUrl: string;
  createdAt: Date;
  updatedAt: Date;
}

export interface ItemVariant {
  color: Colors;
  sizeStock: SizeStock[];
}

export interface SizeStock {
  id: string;
  size: string;
  stock: number;
}

export enum Colors {
  RED = 'RED',
  BLUE = 'BLUE',
  GREEN = 'GREEN',
  BLACK = 'BLACK',
  WHITE = 'WHITE',
  INDIGO = 'INDIGO',
  GRAY = 'GRAY',
  ORANGE = 'ORANGE',
  PINK = 'PINK',
}
