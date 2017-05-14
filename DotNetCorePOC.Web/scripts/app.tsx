/// <reference path="../typings/modules/react-dom/index.d.ts" />
/// <reference path="../typings/modules/react/index.d.ts" />

import * as React from "react";
import * as ReactDOM from "react-dom";
import Hello from "./hello";

ReactDOM.render(
  <Hello name="Willson" />,
  document.getElementById("root")
);