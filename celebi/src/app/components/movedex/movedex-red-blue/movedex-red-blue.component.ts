import { Component, Injectable, OnInit } from '@angular/core';
import { Move } from 'src/app/objects/move';
import { MoveService } from './movedex-red-blue.service';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { MovedexAddComponent } from '../movedex-add/movedex-add.component';
import { MovedexUpdateComponent } from '../movedex-update/movedex-update.component';
import { Delete } from 'src/app/objects/delete';
import { MovedexDeleteComponent } from '../movedex-delete/movedex-delete.component';
import { AdminService } from '../../users/admin/admin.service';
import { Role } from 'src/app/objects/role';

@Component({
  selector: 'app-movedex-red-blue',
  templateUrl: './movedex-red-blue.component.html',
  styleUrls: ['./movedex-red-blue.component.css']
})
export class MovedexRedBlueComponent implements OnInit {
  @Injectable({
    providedIn: 'root'
  })
  move: Move = <Move>{ };
  title = 'celebi';

  constructor( private moveService: MoveService, private dialog: MatDialog, private router: Router,
    private adminService: AdminService) { }

  marray: Move[] = [];
  delete: Delete = {delete: false};
  userName = "";
  message = "";
  isVisible = false;
  roles: Role[] = [];
  r: Role = {name: ""};

  ngOnInit() {
      this.userName = this.adminService.displayLogin();
      this.AuthorizedToView(this.userName);
      this.moveService.getMove().subscribe((data: Move[]) => {
      this.marray = data;
    });
  }

  openAddDialog(): void {
    const dialogRef = this.dialog.open(MovedexAddComponent, {
      data: {
        id: this.move.id,
        name: this.move.name
        },
    });

    dialogRef.afterClosed().subscribe(result => {
      this.move = result;
      this.message = "You added " + this.move.name;
      this.addMove(result);
    });
  }

  openUpdateDialog(): void{
    const dialogRef = this.dialog.open(MovedexUpdateComponent, {
      data: {
        id: this.move.id,
        name: this.move.name
        },
    });

    dialogRef.afterClosed().subscribe(result => {
      this.move = result;
      this.message = "You updated " + this.move.name;
      this.updateMove(result);
    });
  }

  openDeleteDialog(): void{
    const dialogRef = this.dialog.open(MovedexDeleteComponent, {
      data: this.move.id
    });

    dialogRef.afterClosed().subscribe(result => {
      this.message = "You deleted " + result;
      this.removeMove(result);
    });
  }

  //GET
  getMove(){
    this.moveService.getMove().subscribe((data: Move[]) => {
      this.marray = data;
    });
  }

  //POST
  addMove(move: Move){
    this.moveService.addMove(move).subscribe(response => {
      this.router.navigate(['/movedexRedBlue']);
      this.refresh();
    });

  }//PUT
  updateMove(move: Move){
    this.moveService.updateMove(move).subscribe(response => {
      this.router.navigate(['/movedexRedBlue']);
      this.refresh();
    });

  }//DELETE
  removeMove(id: number){
    this.moveService.removeMove(id).subscribe((data: Delete) => {
      this.delete = data;
      this.router.navigate(['/movedexRedBlue']);
      this.refresh();
    });
  }

  refresh(): void{
    window.location.reload();
  }

  AuthorizedToView(userName: string) {
    this.adminService.getRoles(String(userName)).subscribe((role: Role[]) => {
      role.forEach(element => {
        this.r = {name:element.toString()};
        this.roles.push(this.r);
      });
      this.roles.forEach(x => {
        if(x.name == "Admin"){
          this.isVisible = true;
        }
      });
    });
  }
}