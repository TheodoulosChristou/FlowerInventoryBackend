import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-flowers',
  imports: [CommonModule,FormsModule],
  templateUrl: './flowers.component.html',
  styleUrl: './flowers.component.css'
})
export class FlowersComponent {
  flowers = [
    { flowerId: 1, name: 'Rose', category: 'Romantic', price: 2.5 },
    { flowerId: 2, name: 'Tulip', category: 'Spring', price: 1.8 }
  ];

  nextId = 3; // Simulated ID generator

  newFlower = {
    flowerId: 0,
    name: '',
    category: '',
    price: 0
  };

  onSubmit(form: NgForm) {
    if (form.valid) {
      this.newFlower.flowerId = this.nextId++;
      this.flowers.push({ ...this.newFlower });
      this.newFlower = { flowerId: 0, name: '', category: '', price: 0 };
      form.resetForm();
    }
  }

  onEdit(flower: any) {
    console.log('Edit clicked:', flower);
  }

  onDelete(flower: any) {
    this.flowers = this.flowers.filter(f => f.flowerId !== flower.flowerId);
  }
}
