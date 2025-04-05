import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'statusColor',
  standalone: true,
})
export class StatusColorPipe implements PipeTransform {
  transform(stockStatus: string): string {
    if (stockStatus.includes('rupture de stock')) {
      return 'background-red';
    }
    if (stockStatus.includes('stock faibles')) {
      return 'background-orange';
    }
    if (stockStatus.includes('stock sont bons')) {
      return 'background-green';
    }
    return '';
  }
}
