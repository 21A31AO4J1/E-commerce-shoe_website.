import { Pipe, PipeTransform } from '@angular/core';
import { ItemVariant, SizeStock } from '../../model/CatalogProduct';

@Pipe({
  name: 'stockstatus',
  standalone: true,
})
export class StockstatusPipe implements PipeTransform {
  transform(variants: ItemVariant[]) {
    let lowStock: number | string[] = [];
    let outOfStock: number | string[] = [];

    for (let item of variants) {
      for (let stock of item.sizeStock) {
        if (stock.stock < 1) outOfStock.push(stock.size);
        if (stock.stock < 6) lowStock.push(stock.size);
      }
    }
    if (outOfStock.length > 0)
      return `Les tailles ${outOfStock} est en rupture de stock`;
    if (lowStock.length > 0) return 'Une des tailles a un stock faibles';
    return 'Le niveaux de stock sont bons';
  }
}
