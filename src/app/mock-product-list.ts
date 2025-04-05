import CatalogProduct from './model/CatalogProduct';

export const products: CatalogProduct[] = [
  {
    id: '1',
    name: 'Air Max Elite',
    title: 'Chaussures de course haute performance',
    description:
      'Découvrez le confort et les performances ultimes avec les chaussures Air Max Elite.',
    price: 150,
    stockQuantity: 12,
    category: 'Chaussures de course',
    brand: 'Nike',
    size: '42',
    color: 'RED',
    imageUrl: 'assets/images/shoes1.png',
    createdAt: new Date(),
    updatedAt: new Date()
  },
  {
    id: '2',
    name: 'Ultra Boost',
    title: 'Chaussures de running confortables',
    description:
      'Les chaussures Ultra Boost offrent un confort exceptionnel pour vos séances de running.',
    price: 180,
    stockQuantity: 8,
    category: 'Chaussures de running',
    brand: 'Adidas',
    size: '41',
    color: 'BLUE',
    imageUrl: 'assets/images/shoes2.png',
    createdAt: new Date(),
    updatedAt: new Date()
  },
  {
    id: '3',
    name: 'Cloud Runner',
    title: 'Chaussures de course légères',
    description:
      'Les Cloud Runner sont conçues pour offrir une expérience de course légère et réactive.',
    price: 130,
    stockQuantity: 15,
    category: 'Chaussures de course',
    brand: 'On Running',
    size: '40',
    color: 'BLACK',
    imageUrl: 'assets/images/shoes3.png',
    createdAt: new Date(),
    updatedAt: new Date()
  },
  {
    id: '4',
    name: 'Speed Elite',
    title: 'Chaussures de compétition',
    description:
      'Les Speed Elite sont conçues pour les coureurs cherchant à améliorer leurs performances en compétition.',
    price: 200,
    stockQuantity: 5,
    category: 'Chaussures de compétition',
    brand: 'Hoka One One',
    size: '43',
    color: 'WHITE',
    imageUrl: 'assets/images/shoes4.png',
    createdAt: new Date(),
    updatedAt: new Date()
  },
  {
    id: '5',
    name: 'Trail Master',
    title: 'Chaussures de trail',
    description:
      'Les Trail Master sont conçues pour affronter les terrains accidentés avec confiance et stabilité.',
    price: 160,
    stockQuantity: 10,
    category: 'Chaussures de trail',
    brand: 'Salomon',
    size: '42',
    color: 'GREEN',
    imageUrl: 'assets/images/shoes5.png',
    createdAt: new Date(),
    updatedAt: new Date()
  }
];
