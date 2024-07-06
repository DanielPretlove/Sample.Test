export default function UserCreate({ create }) {
  return (
    <Dialog
      className="dialog"
      open={dialog.create}
      onClose={() => dialog.dispatch({ type: "close" })}
    >
      <DialogTitle>
        <div className="close">
          <CloseIcon
            onClick={() => {
              dialog.dispatch({ type: "close" });
            }}
          />
        </div>
        <Typography variant="h3" textAlign={"center"}>
          Add New User
        </Typography>
      </DialogTitle>
      <DialogContent>
        <div className="container">
          <div className="content-container">
            <Box mb={3}>
              <TextField
                fullWidth
                label="Episodes"
                name="episodes"
                value={user.FirstName}
                onChange={user.handleChange}
                variant="outlined"
                multiline
              />

              <TextField
                fullWidth
                label="Episodes"
                name="episodes"
                value={user.FirstName}
                onChange={user.handleChange}
                variant="outlined"
                multiline
              />

              <TextField
                fullWidth
                label="Episodes"
                name="episodes"
                value={user.LastName}
                onChange={user.handleChange}
                variant="outlined"
                multiline
              />

              <TextField
                fullWidth
                label="Episodes"
                name="episodes"
                value={user.Email}
                onChange={user.handleChange}
                variant="outlined"
                multiline
              />

            <DateTime
                fullWidth
                label="Episodes"
                name="episodes"
                value={user.DateAdded}
                onChange={user.handleDateTimeChange}
                variant="outlined"
                multiline
              />
            </Box>
          </div>
        </div>
      </DialogContent>
      <DialogActions>
        <Button onClick={() => user.Add(user.data)}>Add</Button>
        <Button onClick={() => dialog.dispatch({ type: "close" })}>
          Cancel
        </Button>
      </DialogActions>
    </Dialog>
  );
}
