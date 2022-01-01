$("#valid-form").validate({
    rules: {
        firstname: "required",
        lastname: "required",
        email: "required email",

    },
    messages: {
        firstname: "*",
        lastname: "*",
        email: {
            required: "*",
            email: "Please input your correct email address.",
        },
    }
})