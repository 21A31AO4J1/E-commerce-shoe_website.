import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-search-bar',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './search-bar.component.html',
  styleUrl: './search-bar.component.scss',
})
export class SearchBarComponent {
  @Input() search: string = ''; // Use @Input() to receive the value from parent component
  @Output() searchChange = new EventEmitter<string>(); // Use @Output() to emit changes back to parent

  searchProduct() {
    this.searchChange.emit(this.search); // Emit the search value to the parent when the search is triggered
  }

  clearSearch() {
    this.search = '';
    this.searchChange.emit('');
  }
}
