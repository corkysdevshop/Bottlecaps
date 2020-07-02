import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Bottlecap, Space } from '../../../../shared/models';
import { SpaceService } from '../space.service';
import { CdkDrag } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-space-area',
  templateUrl: './space-area.component.html',
  styleUrls: ['./space-area.component.css']
})
export class SpaceAreaComponent implements OnInit {

	spaceCaps: Bottlecap[];

  constructor(private spaceService: SpaceService) { }

	ngOnInit(): void {
		this.spaceService.getSpaceBottlecaps();
		this.spaceService.spacesChanged.subscribe(spaces => {
			this.spaceCaps = spaces.slice();
		}, (err) => { console.log("err: ", err);})
  }

	onDragEnded(event, bottlecap: Bottlecap) {
		console.log("1_onDragEnded: ",event);
	/**/
		let bottlecapElement = event.source.getRootElement();
		console.log("2_BottlecapElement: ", bottlecapElement);

		let bottlecapParentElement = bottlecapElement.parentElement;
		let BottlecapParentBoundingRect = bottlecapParentElement.getBoundingClientRect();
		//console.log("3a_BottlecapParentBoundingRect: ", BottlecapParentBoundingRect);

		let BottlecapBoundingRect = bottlecapElement.getBoundingClientRect();
		//console.log("3b_BottlecapBoundingRect: ", BottlecapBoundingRect);

		let x = BottlecapBoundingRect.x - BottlecapParentBoundingRect.left;
		//console.log("5_BottlecapBoundingRect.x: ", BottlecapBoundingRect.x, " - BottlecapParentBoundingRect.left: ", BottlecapParentBoundingRect.left," = x: ", x);

		let y = BottlecapBoundingRect.y - BottlecapParentBoundingRect.top;
		//console.log("6_y: ", y);
    
		console.log('7_x: ' + x,
			          'y: ' + y);
		this.updatePlace(Math.round(x), Math.round(y), bottlecap.bottlecapId);
	}

	updatePlace(x: number, y: number, spaceCapId: number) {
		const space = new Space();
		space.SpaceId = spaceCapId.toString();
		space.PositionX = x.toString();
		space.PositionY = y.toString();
		console.log("updatePlace x: ", x, " y: ", y);
		this.spaceService.updatePlace(space);
	}

	checkSpaces(event) {
		console.log("spaces in this.spaceService.spaceBottleCapCollection: ", this.spaceService.spaceBottleCapCollection);
		console.log("spaces in this.spaceCaps: ", this.spaceCaps);

		this.resetPositions();
	  console.log("spaces in this.spaceCaps: ", this.spaceCaps);
	}
	resetPositions() {
		for (let space of this.spaceCaps) {
			this.updatePlace(10, 10, space.bottlecapId);
		}
	}
	setPlace(space) {
		var newPositionString = "{x:" + space.positionX + ",y:" + space.positionY + "}";
        // TODO: THIS STRING NEEDS TO GO INTO THE [cdkDragFreeDragPosition], but it won't allow template binding on the one hand and I can't instantiate multiple local variables from the for loop on the other
		console.log("***space:", newPositionString); //return {x:0,y:0}
		return newPositionString;
	}
}
