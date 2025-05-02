import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Flower } from '../../../../models/flower.model';
import { FlowerService } from '../services/flower.service';
import { RouterModule } from '@angular/router';
import { Category } from '../../../../models/category.model';
import { CommonModule } from '@angular/common';

declare var bootstrap: any;

@Component({
  selector: 'app-add-flower',
  imports: [FormsModule, RouterModule,CommonModule],
  templateUrl: './add-flower.component.html',
  styleUrl: './add-flower.component.css'
})
export class AddFlowerComponent implements OnInit {

  model:Flower;
  categories: Category[] = [];

  constructor(private flowerService:FlowerService) {
    this.model = {
      flowerId: 0,
      name: '',
      price:0,
      category:null,
      categoryId: null
    };
  }

  ngOnInit(): void {
    this.flowerService.getAllCategories().subscribe({
      next: (data: Category[]) => this.categories = data,
      error: (err) => {
        console.error('Failed to fetch categories', err);
        this.showToast('Failed to load categories.', 'danger');
      }
    });
  }


  
  showToast(message: string, type: 'success' | 'danger') {
    const toastEl = document.getElementById('toastMessage');
    const toastBody = document.getElementById('toastBody');
  
    if (toastEl && toastBody) {
      toastEl.classList.remove('bg-success', 'bg-danger');
      toastEl.classList.add(type === 'success' ? 'bg-success' : 'bg-danger');
      toastBody.textContent = message;
  
      const toast = new bootstrap.Toast(toastEl);
      toast.show();
    }
  }
  
  onFormSubmit() {
    this.flowerService.addFlower(this.model).subscribe({
      next: (response: Flower) => {
        this.showToast('Flower created successfully!', 'success');
  
        // Optionally reset the form
        this.model = {
          flowerId: 0,
          name: '',
          price: 0,
          category: null,
          categoryId: null
        };
      },
      error: (err) => {
        console.error(err);
        this.showToast('Failed to create flower.', 'danger');
      }
    });
  }
  
}
