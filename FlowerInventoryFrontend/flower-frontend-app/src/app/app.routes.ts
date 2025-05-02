import { Routes } from '@angular/router';
import { FlowerListComponent } from './features/flowers/flower-list/flower-list.component';
import { AddFlowerComponent } from './features/flowers/add-flower/add-flower.component';

export const routes: Routes = [
    {
        path:'admin/flowers',
        component:FlowerListComponent
    },
    {
        path:'admin/flowers/add',
        component:AddFlowerComponent
    }
];
