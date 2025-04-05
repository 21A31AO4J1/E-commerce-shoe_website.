import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { CarouselComponent } from '../../components/carousel/carousel.component';
import { ManufacturingComponent } from '../../components/manufacturing/manufacturing.component';
import { BannerComponent } from '../../components/banner/banner.component';
import { FooterComponent } from '../../components/footer/footer.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    ButtonModule,
    CarouselComponent,
    ManufacturingComponent,
    BannerComponent,
    FooterComponent,
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {}
