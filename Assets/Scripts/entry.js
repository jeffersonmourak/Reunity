function onClick() {
    log("clicked");
}

Ui.Element(
    {
        name: "button",
        props: {
            children: [
                {
                    name: "text",
                    props: {
                        children: ["Hello world"]
                    }
                }]
        }
    }
);