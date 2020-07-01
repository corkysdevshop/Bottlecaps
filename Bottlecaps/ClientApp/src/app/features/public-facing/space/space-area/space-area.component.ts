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
	/**/bottlecap.PositionX
		let bottlecapElement = event.source.getRootElement();
		console.log("2_BottlecapElement: ", bottlecapElement);

		let bottlecapParentElement = bottlecapElement.parentElement;
		let BottlecapParentBoundingRect = bottlecapParentElement.getBoundingClientRect();
		console.log("3a_BottlecapParentBoundingRect: ", BottlecapParentBoundingRect);

		let BottlecapBoundingRect = bottlecapElement.getBoundingClientRect();
		console.log("3b_BottlecapBoundingRect: ", BottlecapBoundingRect);



		let parentPosition = this.getPosition(bottlecapElement);
		console.log("4_parentPosition: ", parentPosition);

		let x = BottlecapBoundingRect.x - BottlecapParentBoundingRect.left;
		console.log("5_boundingClientRect.x: ",BottlecapBoundingRect.x," - parentPosition.left: ",parentPosition.left," = x: ", x);

		let y = BottlecapBoundingRect.y - BottlecapParentBoundingRect.top;
		console.log("6_y: ", y);
    

		console.log('7_x: ' + x,
			          'y: ' + y);
		this.updatePlace(Math.round(x), Math.round(y), bottlecap.bottlecapId);
	}

	getPosition(bcEl) {
		let x = 0;
		let y = 0;
		while (bcEl && !isNaN(bcEl.offsetLeft) && !isNaN(bcEl.offsetTop)) {
			x += bcEl.offsetLeft - bcEl.scrollLeft;
			y += bcEl.offsetTop - bcEl.scrollTop;
			bcEl = bcEl.offsetParent;
		}
		return { top: y, left: x };
	}

	updatePlace(x: number, y: number, spaceCapId: number) {
		const space = new Space();
		space.SpaceId = spaceCapId.toString();
		space.PositionX = x.toString();
		space.PositionY = y.toString();
		console.log("updatePlace x: ", x, " y: ", y);
		this.spaceService.updatePlace(space);
	}

	checkSpace(event) {
    console.log("checkSpace()")
		console.log("event: ", event);
		let element = event.source.getRootElement();
		console.log("element: ", element);
		let boundingClientRect = element.getBoundingClientRect();
		console.log("boundingClientRect: ", boundingClientRect);
		let parentPosition = this.getPosition(element);
		console.log("parentPosition: ", parentPosition);
		let x = boundingClientRect.x - parentPosition.left;
		console.log("x: ", x);
		let y = boundingClientRect.y - parentPosition.top;
		console.log("y: ", y);
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
}
